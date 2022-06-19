import * as React from 'react';
import {ChangeEvent, Component} from 'react';
import {Mapper} from "../Mapper/Mapper";
import {ProductCategory} from "../Enum/ProductCategory";
import {ProductView} from "../ViewModel/productView";
import {CoinView} from "../ViewModel/coinView";
import {OrderView} from "../ViewModel/orderView";
import {CoinCategory} from "../Enum/CoinCategory";
import {Language} from "../Language/Language";
import {AdminModalProduct} from "../Modal/adminModalProduct";

type Props = {}

type State = {
	products: ProductView[];
	product: ProductView;
	coins: CoinView[];
	coin: CoinView;
	orders: OrderView[];
	ids: number[];
	showModalProduct: boolean;
}

export class Home extends Component<Props, State> {
	constructor(props: Props) {
		super(props);
		
		this.state = {
			products: [],
			product: {
				id: 0,
				name: "",
				countProduct: 0,
				price: 0,
				description: "",
				category: ProductCategory.food,
				isRemoved: false
			}, 
			coins:[],
			coin: {
				id: 0,
				coinCategory: CoinCategory.one,
				maxCoinCount: 0,
				nowCoinCount: 0
			}, 
			orders:[],
			ids: [],
			showModalProduct: false
		}
	}
	
	componentDidMount() {
		this.getProducts();
		this.getCoins();
		this.getOrderHistory();
	}

	async getProducts(){
		const response = await fetch('getproducts');
		const request = await response.json();
		const products = Mapper.mapToProductViews(request)
		this.setState({products: products})
	}
	
	async getProductsRemoved(){
		const response = await fetch('getproductsremoved');
		const request = await response.json();
		const products = Mapper.mapToProductViews(request)
		this.setState({products: products})
	}

	async getProductsNotRemoved(){
		const response = await fetch('getproductsnotremoved');
		const request = await response.json();
		const products = Mapper.mapToProductViews(request)
		this.setState({products: products})
	}

	async getProductByCategory(category: ProductCategory){
		const response = await fetch('getproductscategory?category='+ category.toString());
		const request = await response.json();
		const products = Mapper.mapToProductViews(request)
		this.setState({products: products})
	}

	async getCoins(){
		const response = await fetch('getcoins');
		const request = await response.json();
		const coins = Mapper.mapToCoinViews(request)
		this.setState({coins: coins})
	}

	async getOrderHistory(){
		const response = await fetch('getorderhistory');
		const request = await response.json();
		const orders = Mapper.mapToOrderViews(request)
		this.setState({orders: orders})
	}

	async removeProduct(productId: number){
		await fetch('removeproduct', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(productId)
		});
		await this.getProducts();
	}

	async updateProductCount(productId: number, e:ChangeEvent<HTMLInputElement>){
		let count = Number(e.target.value);
		const data = {productId, count}
		
		await fetch('removeproduct', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(data)
		});
		await this.getProducts();
	}

	async removeProducts(productIds: number[]){
		if(this.state.ids.length == 0) return alert("Вы не выбрали ни одной операции");
		await fetch('removeproducts', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(productIds)
		});
		await this.getProducts();
	}

	async getProduct(id: number){
		const response = await fetch('getproduct?id='+ id.toString());
		const request = await response.json();
		const product = Mapper.mapToProductView(request)
		this.setState({product: product})
		this.openProductModal();
	}
	
	updateIds(e:ChangeEvent<HTMLInputElement>) {
		const checked = e.target.checked;
		const id = Number(e.target.value);
		if(!this.state.ids.includes(id) && checked){
			this.state.ids.push(id);
		}
		if(this.state.ids.includes(id) && !checked){
			let index = this.state.ids.indexOf(id);
			this.state.ids.splice(index, 1)
		}
	}

	async updateCoinCount(coinId: number, e:ChangeEvent<HTMLInputElement>){
		let maxCoinCount = Number(e.target.value);
		const data = {coinId, maxCoinCount}
		
		await fetch('updatemaxcoin', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(data)
		});
		await this.getCoins();
	}
	
	getProductName(productId: number){
		return this.state.products.find(product => product.id == productId)?.name;
	}
	
	openAddModel(){
		this.setState({  showModalProduct: true, product: {id: 0, name: "", countProduct: 0, price: 0, category: ProductCategory.food, description: "", isRemoved: false}});
	}
	
	openProductModal = () =>{
		this.setState({  showModalProduct: true });
	}

	closeProductModal = () =>{
		this.setState({  showModalProduct: false });
	}
	
  render () {
    return (
      <div>
          <h1>Панель администратора</h1>
		  <br/>
		  <h2>Продукты</h2>
		  <input onClick={() => this.getProducts()} type="radio" id="contactChoice1"
				 name="product"/>
			  <label htmlFor="contactChoice1">Показать все</label>
			  <input onClick={() => this.getProductsRemoved()} type="radio" id="contactChoice2"
					 name="product" value="phone"/>
				  <label htmlFor="contactChoice2">Показать только удаленные</label>
				  <input onClick={() => this.getProductsNotRemoved()} type="radio" id="contactChoice3"
						 name="product" value="mail"/>
					  <label htmlFor="contactChoice3">Показать не удаленные</label>
		  <table className='table table-striped' aria-labelledby="tabelLabel">
			  <thead>
			  <tr>
				  <th>Наименование продукта</th>
				  <th>Количество продукта в машине</th>
				  <th>Стоимость продукта</th>
				  <th>Описание</th>
				  <th>Категория продукта</th>
				  <th><button onClick={() => this.removeProducts(this.state.ids)} className="btn btn-danger">Удалить</button></th>
				  <th><button onClick={() => this.openAddModel()} className="btn btn-success">Добавить новый продукт</button></th>
				  <th></th>
				  <th>Есть/Удален</th>
			  </tr>
			  </thead>
			  <tbody>
			  {this.state.products.map(product =>
				  <tr key={product.id}>
					  <td onClick={() => this.getProduct(product.id)}>{product.name}</td>
					  <td><input type="number" min={0} max={100} step={1} value={product.countProduct} onChange={(e) => this.updateProductCount(product.id, e)}/></td>
					  <td>P{product.price}</td>
					  <td>{product.description}</td>
					  <td>{Language.toProductCategory(product.category)}</td>
					  <td><input onChange={(e) => this.updateIds(e)} value={product.id} type="checkbox"/></td>
					  <td></td>
					  <td><button onClick={() => this.removeProduct(product.id)} className="btn btn-danger">Удалить</button></td>
					  <td>{product.isRemoved ? "Удален" : "Есть"}</td>
				  </tr>
			  )}
			  </tbody>
		  </table>
		  <br/>
		  <h2>Монеты</h2>
		  <table className='table table-striped' aria-labelledby="tabelLabel">
			  <thead>
			  <tr>
				  <th>Ценность монеты</th>
				  <th>Максимальное количество монет</th>
				  <th>Количество монет на данный момент</th>
			  </tr>
			  </thead>
			  <tbody>
			  {this.state.coins.map(coin =>
				  <tr key={coin.id}>
					  <td>{Language.toCoinCategory(coin.coinCategory)}</td>
					  <td><input type="number" min={0} max={100} step={1} value={coin.maxCoinCount} onChange={(e) => this.updateCoinCount(coin.id, e)}/></td>
					  <td>{coin.nowCoinCount}</td>
				  </tr>
			  )}
			  </tbody>
		  </table>
		  <br/>
		  <h2>История покупок</h2>
		  <table className='table table-striped' aria-labelledby="tabelLabel">
			  <thead>
			  <tr>
				  <th>Дата покупки</th>
				  <th>Купленный товар/продукт/напиток</th>
			  </tr>
			  </thead>
			  <tbody>
			  {this.state.orders.map(order =>
				  <tr key={order.id}>
					  <td>{order.createdDateTime.toString().slice(0,10)}</td>
					  <td>{this.getProductName(order.productId)}</td>
				  </tr>
			  )}
			  </tbody>
		  </table>
		  <AdminModalProduct product={this.state.product} getProducts={() => this.getProducts()} isShown={this.state.showModalProduct} hide={() => this.closeProductModal()}/>
      </div>
    );
  }
}


import * as React from 'react';
import {Component} from 'react';
import "./NavMenu.css"
import {Mapper} from "../Mapper/Mapper";
import {ProductView} from "../ViewModel/productView";
import {ProductCategory} from "../Enum/ProductCategory";
import {Language} from "../Language/Language";
import {CoinView} from "../ViewModel/coinView";
import {ProductMachine} from "../Modal/ProductMachine";

type Props ={}

type State = {
  products: ProductView[],
  product: ProductView,
  showModal: boolean,
  coins: CoinView[]
}

export class FetchData extends Component<Props, State> {

  constructor(props: Props) {
    super(props);
    
    this.state ={
      products: [],
      showModal: false,
      coins: [],
      product:{
        id: 0,
        name: "",
        countProduct: 0,
        price: 0,
        description: "",
        category: ProductCategory.food,
        isRemoved: false
      }
    }
  }
  
  componentDidMount() {
    this.getProducts();
    this.getCoins();
  }

  async getProducts(){
    const response = await fetch('getproducts');
    const request = await response.json();
    const products = Mapper.mapToProductViews(request)
    this.setState({products: products})
  }

  async getProduct(id: number){
    const response = await fetch('getproduct?id='+ id.toString());
    const request = await response.json();
    const product = Mapper.mapToProductView(request)
    this.setState({product: product})
    this.openModal();
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
  
  openModal = () =>{
    this.setState({ showModal: true });
  }

  closeModal = () =>{
    this.setState({ showModal: false });
  }
  
  render() {
    const category = [0, 1, 2];
    
    return (
      <div>
        {category.map(cat => 
        <button className="btn btn-success" onClick={() => this.getProductByCategory(cat)}>{Language.toProductCategory(cat)}</button>
        )}
        <div className="card-columns">
          {this.state.products.map(product =>
              <div id={product.id.toString()} className="card">
                <h1>{product.name}</h1>
                <p className="price">P{product.price}</p>
                <p>{product.description}</p>
                <p>
                  <button onClick={() => this.getProduct(product.id)}>Купить</button>
                </p>
              </div>
          )}
        </div>
        <ProductMachine 
            hide={() => this.closeModal()} 
            coins={this.state.coins} 
            isShown={this.state.showModal} 
            product={this.state.product}
            getProducts={() => this.getProducts()}
            getCoins={() => this.getCoins()}
        />
      </div>
    );
  }
}

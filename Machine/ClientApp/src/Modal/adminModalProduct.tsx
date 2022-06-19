import React, {ChangeEvent, Component} from "react";
import {Modal, ModalBody, ModalFooter, ModalHeader} from "reactstrap";
import {ProductView} from "../ViewModel/productView";
import {ProductCategory} from "../Enum/ProductCategory";
import {ProductBlank} from "../Blank/productBlank";

export interface Props{
	isShown: boolean;
	hide: () => void;
	product: ProductView;
	getProducts: () => void;
}

type State = {
	name: string;
	category: ProductCategory;
	description: string;
	price: number;
	countProduct: number;
}

export class AdminModalProduct extends Component<Props, State>{
	constructor(props: Props) {
		super(props);
		
		this.state = {
			name: "",
			category: ProductCategory.food,
			description: "",
			price: 0,
			countProduct: 0
		}
	}
	
	async addProduct(){
		if(this.state.countProduct <= 0 || this.state.price <= 0){
			return alert("Количество продукта и цена указаны не верно")
		}
		
		const blank = new ProductBlank(0, this.state.name, this.state.countProduct, this.state.price, this.state.description, this.state.category, false)
		
		await fetch('addproduct', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(blank)
		});
		
		this.props.hide()
		this.props.getProducts();
	}
	
	async updateProduct(){
		if(this.state.countProduct <= 0 || this.state.price <= 0){
			return alert("Количество продукта и цена указаны не верно")
		}
		
		const blank = new ProductBlank(0, this.state.name, this.state.countProduct, this.state.price, this.state.description, this.state.category, false)
		
		await fetch('updateproduct', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json;charset=utf-8'
			},
			body: JSON.stringify(blank)
		});
		
		this.props.hide()
		this.props.getProducts();
	}
	
	updateName(e:ChangeEvent<HTMLInputElement>){
		this.setState({name: e.target.value.toString()})
	}
	
	updateCount(e:ChangeEvent<HTMLInputElement>){
		this.setState({price: Number(e.target.value)})
	}
	
	updatePrice(e:ChangeEvent<HTMLInputElement>){
		this.setState({countProduct: Number(e.target.value)})
	}
	
	updateDescription(e:ChangeEvent<HTMLTextAreaElement>){
		this.setState({description: e.target.value.toString()})
	}
	
	updateCategory(e:ChangeEvent<HTMLSelectElement>){
		this.setState({category: Number(e.target.value)   })
	}

	render() {
		return (
			<div>
				<Modal
					size="lg"
					aria-labelledby="contained-modal-title-vcenter"
					isOpen={this.props.isShown}
					fade={false}
				>
					<ModalHeader>
						<h1>{this.props.product.id != 0 ? 'Редактирование продукта '+ this.props.product.name : 'Добавление нового продукта'}</h1>
					</ModalHeader>
					<ModalBody>
						<div className="input-group mb-3">
							<div className="input-group-prepend">
								<span className="input-group-text" id="basic-addon1">Введите наименование продукта:</span>
							</div>
							<input onChange={(e) => this.updateName(e)} type="text" className="form-control" placeholder="Наименование продукта" aria-label="Username"
								   aria-describedby="basic-addon1"/>
						</div>
						<div className="input-group mb-3">
							<select onChange={(e) => this.updateCategory(e)} className="custom-select" id="inputGroupSelect02">
								<option selected>Выберите категорию</option>
								<option value="0">Напитки</option>
								<option value="1">Еда</option>
								<option value="2">Сувениры</option>
							</select>
							<div className="input-group-append">
								<label className="input-group-text" htmlFor="inputGroupSelect02">Категория продукта</label>
							</div>
						</div>
						<div className="input-group">
							<div className="input-group-prepend">
								<span className="input-group-text">Описание</span>
							</div>
							<textarea onChange={(e) => this.updateDescription(e)} className="form-control" aria-label="With textarea">{this.props.product.description}</textarea>
						</div>
						<div>
							<span>Цена продукта: </span>
							<input onChange={(e) => this.updatePrice(e)} type="number" min={0} max={100} step={1} defaultValue={this.props.product.id != 0 ? this.props.product.price : 0}/>
						</div>
						<div>
							<span>Количество продукта: </span>
							<input onChange={(e) => this.updateCount(e)} type="number" min={0} max={100} step={1} defaultValue={this.props.product.id != 0 ? this.props.product.countProduct : 0}/>
						</div>
					</ModalBody>
					<ModalFooter>
						<button onClick={this.props.product.id != 0 ? () => this.updateProduct() : () => this.addProduct()} className={this.props.product.id != 0 ? 'btn btn-success' : 'btn btn-primary'}>{this.props.product.id != 0 ? 'Изменить' : 'Добавить'}</button>
						<button onClick={() => this.props.hide()} className={'btn btn-danger'}>Выйти</button>
					</ModalFooter>
				</Modal>
			</div>
		);
	}
}
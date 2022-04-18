function showModalBuy(id) {
	$("#buyProduct").modal('show');
	getProduct(id);
}

function showModalAdd() {
	$("#modalAdd").modal('show');
}

function showModalEdit(id) {
	$("#modalAdd").modal('show');
	getProductForEdit(id);
}

function closeModal(){
	$("#buyProduct").modal('hide');
	location.reload();
}

function closeModalAdd(){
	$("#modalAdd").modal('hide');
	location.reload();
}

function closeModalEdit(){
	$("#modalEdit").modal('hide');
	location.reload();
}

function getProductForEdit(id){
	$.ajax({
		url: '/getproduct',
		method: 'get',
		dataType: 'html',
		data: {id: id},
		success: function (data){
			updateProductEdit(data);
		}
	});
}

function getProduct(id){
	$.ajax({
		url: '/getproduct',
		method: 'get',
		dataType: 'html',
		data: {id: id},
		success: function (data){
			updateProduct(data);
		}
	});
}

function coinOne(id, coin){
	clickCoin(id, coin);
	getProduct(id);
}

function updateProductEdit(data){
	const product = JSON.parse(data);
	let img = document.getElementById('editProductImg');
	let name = document.getElementById('editProductName');
	let price = document.getElementById('editProductPrice');
	let id = document.getElementById('idEditProduct');
	id.value = product.product.id;
	img.value = product.product.img;
	name.value = product.product.image;
	price.value = product.product.image;
}

function updateProduct(data){
	const product = JSON.parse(data);
	if(product.product.price >= product.product.coinBase){
		var one = document.getElementById('one');
		one.disabled = true;
		var two = document.getElementById('two');
		two.disabled = true;
		var five = document.getElementById('five');
		five.disabled = true;
		var ten = document.getElementById('ten');
		ten.disabled = true;
		var buttonBuy = document.getElementById('buy');
		buttonBuy.disabled = false;
		var coinLeft = document.getElementById('coinLeft');
		var difference = product.product.price - product.product.coinBase;
		coinLeft.text = "Итого сдача: " + difference + " ₽";
	}else{
		var nameProduct = document.getElementById('nameProduct');
		var priceProduct = document.getElementById('priceProduct');
		var countCoin = document.getElementById('countCoin');
		nameProduct.text = product.product.name;
		priceProduct.text = product.product.price + " ₽";
		countCoin.text = "Итого монет: " + product.product.coinBase;
	}
}

function getProducts(){
	$.ajax({
		url: '/getproducts',
		method: 'get',
		dataType: 'html',
		data: {id: id}
	});
}

function addProduct(){
	let productName = document.getElementById('addProductName').value;
	let price = document.getElementById('addProductPrice').value;
	let img = document.getElementById('addProductImg').value;

	$.ajax({
		url: '/addproduct',
		method: 'post',
		dataType: 'html',
		data: {productName: productName, price: price, img: img}
	});
}

function editProduct(){
	let productName = document.getElementById('addProductName').value;
	let price = document.getElementById('addProductPrice').value;
	let img = document.getElementById('addProductImg').value;
	let id = document.getElementById('addProductImg').value;

	$.ajax({
		url: '/editproduct',
		method: 'post',
		dataType: 'html',
		data: {id: id, productName: productName, price: price, img: img}
	});
	location.reload();
}

function removeProduct(id){
	$.ajax({
		url: '/removeproduct',
		method: 'post',
		dataType: 'html',
		data: {id: id}
	});
	location.reload();
}

function clickCoin(id, coin){
	$.ajax({
		url: '/clickcoin',
		method: 'post',
		dataType: 'html',
		data: {id: id, coin: coin},
		success: function (data){
			
		}
	});
}

function buyProduct(id){
	$.ajax({
		url: '/buyproduct',
		method: 'post',
		dataType: 'html',
		data: {id: id},
		success: function (){
			closeModal();
		}
	});
}
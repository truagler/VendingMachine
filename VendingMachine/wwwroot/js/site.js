﻿function showModal(id) {
	$("#buyProduct").modal('show');
	getProduct(id);
}

function showModalAdd(id) {
	$("#modalAdd").modal('show');
	getProduct(id);
}

function showModalEdit(id) {
	$("#modalAdd").modal('show');
	getProduct(id);
}

function closeModal(){
	$("#buyProduct").modal('hide');
	location.reload();
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

function addProduct(productName, price, img){
	$.ajax({
		url: '/addproduct',
		method: 'post',
		dataType: 'html',
		data: {productName: productName, price: price, img: img}
	});
}

function editProduct(id, productName, price, img){
	$.ajax({
		url: '/editproduct',
		method: 'post',
		dataType: 'html',
		data: {id: id, productName: productName, price: price, img: img}
	});
}

function removeProduct(id){
	$.ajax({
		url: '/removeproduct',
		method: 'post',
		dataType: 'html',
		data: {id: id}
	});
}

function clickCoin(id, coin){
	$.ajax({
		url: '/clickcoin',
		method: 'post',
		dataType: 'html',
		data: {id: id, coin: coin}
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
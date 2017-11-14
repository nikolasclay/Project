$(document).ready(function () {
	search();
	$('#searchResults').hide();
	getSpecials();
});

//var userInput = $('#searchBox').val();
//var minPrice = $('#minPrice').val();
//var maxPrice = $('#maxPrice').val();
//var minYear = $('#minYear').val();
//var maxYear = $('#maxYear').val();

//$('#submitButton').click(function () {
//	$.when(
//		// Get the HTML
//		$.get("http://localhost:51989/vehicles/make/{make}", function (make) {
//			globalStore.make = make;
//		}),

//		// Get the CSS
//		$.get("http://localhost:51989/vehicles/model/{model}", function (model) {
//			globalStore.model = model;
//		}),

//		$.get("http://localhost:51989/vehicles/year/{year}", function (year) {
//			globalStore.year = year;
//		}),

//		$.get("http://localhost:51989/vehicles/price/{price}", function (price) {
//			globalStore.price = price;
//		}),

//	).then(function () {

//		if (make.search(new RegExp(userInput, "i")) && (price >= minPrice && price <= maxPrice) && (year >= minYear && year <= maxYear)) {
//			var divRow = '<div class="col-md-4 items" id="menuItem" data-id= ' + product.id + '>';
//			divRow += '<button type = "button" class="btn btn-default style="padding-bottom:35px" id="itemButton">';
//			divRow += '<p>' + itemID + '</p>';
//			divRow += '<p>' + name + '</p>';
//			divRow += '<p>' + '$' + price + '</p>';
//			divRow += '<p data-quantity="' + product.quantity + '">' + 'Quantity Left: ' + quantity + '</p>' + '</div>';
//			divRow += '</button>';
//			item.append(divRow);
//		}
//		else if (model.search(new RegExp(userInput, "i")) && (price >= minPrice && price <= maxPrice) && (year >= minYear && year <= maxYear)) {
//			return model;
//		}
//		else if (year.search(new RegExp(userInput, "i")) && (price >= minPrice && price <= maxPrice) && (year >= minYear && year <= maxYear)) {
//			return year;
//		}
//		else if ((price >= minPrice && price <= maxPrice) && (year >= minYear && year <= maxYear)) {
//			return make;
//		}
//		})
//});
function ShowCars() {
	$('#searchResults').show();
	search();
}
function search() {
	var params;
	var searchResults = $('#searchResults');
	params = 'quicksearch=' + $('#quickSearch').val() + '&minprice=' + $('#minPrice').val() + '&maxprice=' + $('#maxPrice').val()
		+ '&minyear=' + $('#minYear').val() + '&maxyear=' + $('#maxYear').val();

	$.ajax({
		type: 'GET',
		url: 'http://localhost:51989/api/vehicle/search?' + params,
		success: function (results) {
			$('#searchResults').empty();

			$.each(results, function (index, vehicle) {
				//var html = '';

				var style = vehicle.bodyStyle.description;
				var trans = vehicle.transmission;
				var exterior = vehicle.exteriorColor.description;
				var interior = vehicle.interiorColor.description;
				var mileage = vehicle.mileage;
				var vin = vehicle.vin;
				var price = vehicle.salePrice;
				var msrp = vehicle.msrp;
				var image = vehicle.image;
				var make = vehicle.vehicleModel.vehicleMake.make;
				var model = vehicle.vehicleModel.modelType;
				var year = vehicle.year;

				var row = '<div class="row">' + '<div class="col-md-3">' + '<img src ="' + image + '" height:100% width:100%" />' +
					'<p>' + year + ' ' + make + ' ' + model + '</p>' + '</div><div class="col-md-9"><p>' + 'Body Style: ' + style + '</p>' +
					'<p>' + 'Interior: ' + interior + '</p>' + 'Sales Price: ' + price + '</p>' +
					'<p>' + 'Trans: ' + trans + '</p>' + '<p>' + 'Mileage: ' + mileage + '</p>' + '<p>' + 'MSRP: ' + msrp + '</p>' +
					'<p>' + 'Color: ' + exterior + '</p>' + '<p>' + 'VIN: ' + vin + '</p>' + '</div>';

				$('#searchResults').html(row);

			});
		},
		error: function () {

		}

	});
}
	function getSpecials() {
		$.ajax({
			type: 'GET',
			url: 'http://localhost:51989/api/vehicle/specials?',
			success: function (result) {
				$('#specialResults').empty();

				$.each(result, function (index, special) {

					var title = special.title;
					var desc = special.description;

					var row = '<div class="row"><h4>' + title + '</h4>' + '</hr>';
					row += '<p>' + desc + '</p>' + '</div>';

					$('#specialResults').html(row);
				});
			},
			error: function () {
			}
});
}

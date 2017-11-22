$(document).ready(function () {
	$('#searchResults').hide();
	$('#details').hide();
});

function newCars() {
	$('#searchResults').show();
	searchNew();
}
function usedCars() {
	$('#searchResults').show();
	searchUsed();
}
function showCars() {
	$('SearchResults').show();
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
				var id = vehicle.vehicleId

				var row = '<div class="row" style="margin-bottom:15px; border: 2px solid black;"><div class="col-xs-3"><img src ="' + image + '" height="65%" width="65%;" style="border: 1px solid black"/>' + year + ' ' + make + ' ' + model + '</div>'
					row += '<div class="col-xs-9"><table style= "width:100%" class="responsive">'
					row += '<tr><td> Body Style: ' + style + '</td><td>Interior: ' + interior + '</td><td>Sales Price: $' + price + '</td></tr>'
					row += '<tr><td>Trans: ' + trans + '</td><td>Mileage: ' + mileage + '</td><td>MSRP: ' + msrp + '</td></tr>'
					row += '<tr><td>Color: ' + exterior + '</td><td>VIN: ' + vin + '</td><td><button type="submit" class="btn btn-primary" onclick="displayDetails(' + id + ')">Details</button></td></tr></table></div></div>'

				$('#searchResults').append(row);

			});
		},
		error: function () {

		}

	});
}
function searchNew() {
	var params;
	var searchResults = $('#searchResults');
	params = 'quicksearch=' + $('#quickSearch').val() + '&minprice=' + $('#minPrice').val() + '&maxprice=' + $('#maxPrice').val()
		+ '&minyear=' + $('#minYear').val() + '&maxyear=' + $('#maxYear').val();


	$.ajax({
		type: 'GET',
		url: 'http://localhost:51989/api/vehicle/searchNew?' + params,
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
				var id = vehicle.vehicleId

				var row = '<div class="row" style="margin-bottom:15px; border: 2px solid black;"><div class="col-xs-4"><img src ="' + image + '" height="100%" width="100%"/>' + year + ' ' + make + ' ' + model + '</div>'
				row += '<div class="col-xs-8"><table style= "width:100%" class="responsive">'
				row += '<tr><td> Body Style: ' + style + '</td><td>Interior: ' + interior + '</td><td>Sales Price: $' + price + '</td></tr>'
				row += '<tr><td>Trans: ' + trans + '</td><td>Mileage: ' + mileage + '</td><td>MSRP: ' + msrp + '</td></tr>'
				row += '<tr><td>Color: ' + exterior + '</td><td>VIN: ' + vin + '</td><td><button type="submit" class="btn btn-primary" onclick="displayDetails(' + id + ')">Details</button></td></tr></table></div></div>'

				$('#searchResults').append(row);

			});
		},
		error: function () {

		}

	});
}
function searchUsed() {
	var params;
	var searchResults = $('#searchResults');
	params = 'quicksearch=' + $('#quickSearch').val() + '&minprice=' + $('#minPrice').val() + '&maxprice=' + $('#maxPrice').val()
		+ '&minyear=' + $('#minYear').val() + '&maxyear=' + $('#maxYear').val();


	$.ajax({
		type: 'GET',
		url: 'http://localhost:51989/api/vehicle/searchUsed?' + params,
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
				var id = vehicle.vehicleId

				var row = '<div class="row" style="margin-bottom:15px; border: 2px solid black;"><div class="col-xs-4"><img src ="' + image + '" height="100%" width="100%"/>' + year + ' ' + make + ' ' + model + '</div>'
				row += '<div class="col-xs-8"><table style= "width:100%" class="responsive">'
				row += '<tr><td> Body Style: ' + style + '</td><td>Interior: ' + interior + '</td><td>Sales Price: $' + price + '</td></tr>'
				row += '<tr><td>Trans: ' + trans + '</td><td>Mileage: ' + mileage + '</td><td>MSRP: ' + msrp + '</td></tr>'
				row += '<tr><td>Color: ' + exterior + '</td><td>VIN: ' + vin + '</td><td><button type="submit" class="btn btn-primary" onclick="displayDetails(' + id + ')">Details</button></td></tr></table></div></div>'

				$('#searchResults').append(row);

			});
		},
		error: function () {

		}

	});
}
function displayDetails(id) {
	$('#searchResults').hide();
	$('#searchBox').hide();
	$('#details').show();


	$.ajax({
		type: 'GET',
		url: 'http://localhost:51989/api/vehicle/' + id,
		success: function (vehicle) {
			//$('#details').empty();

			//$.each(response, function (index, vehicle) {
			var row = '';

			row = '<div class="row" style="margin-bottom:15px;"><div class="col-md-3"><img src ="' + vehicle.image + '" height="100%" width="100%"/>' + vehicle.year + ' ' + vehicle.vehicleModel.vehicleMake.make + ' ' + vehicle.vehicleModel.modelType + '</div>'
			row += '<div class="col-md-9"><table style= "width:100%" class="responsive"><tr></tr>'
			row += '<tr><td> Body Style: ' + vehicle.bodyStyle.description + '</td><td>Interior: ' + vehicle.interiorColor.description + '</td><td>Sales Price: $' + vehicle.salePrice + '</td></tr>'
			row += '<tr><td>Trans: ' + vehicle.transmission + '</td><td>Mileage: ' + vehicle.mileage + '</td><td>MSRP: ' + vehicle.msrp + '</td></tr>'
			row += '<tr><td>Color: ' + vehicle.exteriorColor.description + '</td><td>VIN: ' + vehicle.vin + '</td><td>Description: ' + vehicle.description + '</td>'
			row += '<td><a href="/Home/Contact"><button type="submit" class = "btn btn-primary">Contact Us</button></a></td></tr></table></div></div>'

			$('#details').append(row);

		}
	});
}
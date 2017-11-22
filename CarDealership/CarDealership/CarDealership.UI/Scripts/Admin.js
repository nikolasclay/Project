$(document).ready(function () {
	$('#searchResults').hide();
	$('#details').hide();
});

function showCars() {
	$('#searchResults').show();
	search();
}
function showDetails() {
	//$('#details').show();
	$('#searchResults').hide();
	$('#searchBox').hide();
	displayDetails();
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

				var row = '<div class="row" style="margin-bottom:15px; border: 2px solid black;"><div class="col-md-3"><img src ="' + image + '" height="100%" width="100%;" style="border: 2px solid black"/>' + year + ' ' + make + ' ' + model + '</div>'
				row += '<div class="col-md-9"><table style= "width:100%" class="responsive">'
				row += '<tr><td> Body Style: ' + style + '</td><td>Interior: ' + interior + '</td><td>Sales Price: $' + price + '</td></tr>'
				row += '<tr><td>Trans: ' + trans + '</td><td>Mileage: ' + mileage + '</td><td>MSRP: ' + msrp + '</td></tr>'
				row += '<tr><td>Color: ' + exterior + '</td><td>VIN: ' + vin + '</td><td><a href="/Admin/Edit/' + id + '"><button type="submit" class="btn btn-primary">Edit</button></a></td></tr></table></div></div>'

				$('#searchResults').append(row);

			});
		},
		error: function () {

		}

	});
}
function displayDetails(id) {
	$('#details').show();
	$.ajax({
		type: 'GET',
		url: 'http://localhost:51989/api/vehicle' + id,
		success: function (response) {
			$('#details').empty();

			$.each(response, function (index, vehicle) {
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
				var desc = vehicle.description;

				var row = '<div class="row" style="margin-bottom:15px:"><div class="col-xs-3"><img src ="' + image + '" height="65%" width="65%"/>' + year + ' ' + make + ' ' + model + '</div>'
				row += '<div class="col-xs-9"><table style= "width:100%" class="responsive"><tr></tr>'
				row += '<tr><td> Body Style: ' + style + '</td><td>Interior: ' + interior + '</td><td>Sales Price: $' + price + '</td></tr>'
				row += '<tr><td>Trans: ' + trans + '</td><td>Mileage: ' + mileage + '</td><td>MSRP: ' + msrp + '</td></tr>'
				row += '<tr><td>Color: ' + exterior + '</td><td>VIN: ' + vin + '</td><td>Description: ' + desc + '</td>'
				row += '<td><button type="submit" class = "btn btn-primary" onclick="contactUs()">Contact Us</button></td></tr></table></div></div>'

				$('#details').append(row);

			});
		},
		error: function () {

		}

	});
}

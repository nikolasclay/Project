$(document).ready(function () {
	$(".btn.btn-primary").click(function () {
		if ($(this).text().search(new RegExp("purchase", "i")) > -1) {
			var vehicleID = $(this).attr("id")
			createCookie("vehicleID", vehicleID, "1800000", "/")
		}
	});
});
function createCookie(name, value, ms, path) {
	if (!name || !value) {
		return;
	}
	var d;
	var cpath = path ? '; path=' + path : '';
	var expires = '';
	if (ms) {
		d = new Date();
		d.setTime(d.getTime() + ms);
		expires = '; expires=' + d.toUTCString();
	}
	document.cookie = name + "=" + value + expires + cpath;
}
function showCars() {
	$('#searchResults').show();
	search();
}
function showDetails() {
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
				var row = '';

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

				row = '<div class="row" style="margin-bottom:15px;"><div class="col-md-3"><img src ="' + vehicle.image + '" height="100%" width="100%" style="border:2px solid black;"/>' + vehicle.year + ' ' + vehicle.vehicleModel.vehicleMake.make + ' ' + vehicle.vehicleModel.modelType + '</div>'
				row += '<div class="col-md-9"><table style= "width:100%" class="responsive"><tr></tr>'
				row += '<tr><td> Body Style: ' + vehicle.bodyStyle.description + '</td><td>Interior: ' + vehicle.interiorColor.description + '</td><td>Sales Price: $' + vehicle.salePrice + '</td></tr>'
				row += '<tr><td>Trans: ' + vehicle.transmission + '</td><td>Mileage: ' + vehicle.mileage + '</td><td>MSRP: ' + vehicle.msrp + '</td></tr>'
				row += '<tr><td>Color: ' + vehicle.exteriorColor.description + '</td><td>VIN: ' + vehicle.vin + '</td><td>Description: ' + vehicle.description + '</td>'
				row += '<td><a href="/Sales/Purchase/' + vehicle.vehicleId + '"><button type="submit" class="btn btn-primary">Purchase</button></a ></td ></tr ></table ></div ></div > '

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

	//error: function() {

	//}
}

$(document).ready(function (){
	returnSale();
});

function returnSale() {
	var pagePath = window.location.pathname.split("/");
	var id = pagePath[3];

	$.ajax({
		type: 'GET',
		url: 'http://localhost:51989/api/vehicle/' + id,
		success: function (vehicle) {
			var row = '';

			row = '<div class="row"><div class="col-md-3"><img src ="' + vehicle.image + '" height="100%" width="100%"/>' + vehicle.year + ' ' + vehicle.vehicleModel.vehicleMake.make + ' ' + vehicle.vehicleModel.modelType + '</div>'
			row += '<div class="col-md-9"><table style= "width:100%" class="responsive"><tr></tr>'
			row += '<tr><td> Body Style: ' + vehicle.bodyStyle.description + '</td><td>Interior: ' + vehicle.interiorColor.description + '</td><td>Sales Price: $' + vehicle.salePrice + '</td></tr>'
			row += '<tr><td>Trans: ' + vehicle.transmission + '</td><td>Mileage: ' + vehicle.mileage + '</td><td>MSRP: ' + vehicle.msrp + '</td></tr>'
			row += '<tr><td>Color: ' + vehicle.exteriorColor.description + '</td><td>VIN: ' + vehicle.vin + '</td><td>Description: ' + vehicle.description + '</td>'
			row += '</tr></table></div></div>'
			row += '</hr></br>'

			$('#details').append(row).attr("style","display:block");

		}
	});
}
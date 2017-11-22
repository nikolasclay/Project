$(document).ready(function () {
	showFeatured();
	getSpecials();
});
function showFeatured() {

	$.ajax({
		type: 'GET',
		url: 'http://localhost:51989/api/vehicle/featured',
		success: function (results) {
			//var row = '';
			//for (i = 0; i < results.length; i++) {
			//	row += '<div style="text-align:center; border: 1px solid black height:"300px" width:300px"" class="col-xs-3"><img src="' + results[i].image + '" height="100%" width="100%" />'
			//	row += '<h4>' + results[i].year + ' ' + results[i].vehicleModel.vehicleMake.make + ' ' + results[i].vehicleModel.modelType
			//	row += '</h4><p>Sales Price: $' + results[i].salePrice + '</p></div>'
			//}
			$.each(results, function (index, vehicle) {
				var row = "";

				var year = vehicle.year;
				var make = vehicle.vehicleModel.vehicleMake.make;
				var model = vehicle.vehicleModel.modelType;
				var image = vehicle.image;
				var price = vehicle.salePrice;
				
				row = '<div class = "col-md-3" style="text-align:center; display= "overflow:hidden";"><img src="' + image + '" height="100%" width="100%" style ="border:2px solid black;">'
				row += '<h5>' + year + ' ' + make + ' ' + model
				row += '</h5><p>Sales Price: $' + price + '</p></h4></div>'
				

				$('#featured').append(row);
			});
		},
		error: function (jqxhr, techstatus, errorthrow) {

		}
	});
}
function getSpecials() {
	$.ajax({
		type: 'GET',
		url: 'http://localhost:51989/api/vehicle/special',
		success: function (result) {
			$('#specialResults').empty();

			$.each(result, function (index, special) {

				var title = special.title;
				var desc = special.description;

				var row = '<div class="row" style= "text-align:center; border: 2px solid black; margin-bottom:10px;"><h4>' + title + '</h4>' + '</hr>';
				row += '<p>' + desc + '</p>' + '</div>';

				$('#specialResults').append(row);
			});
		},
		error: function () {
		}
	});
}

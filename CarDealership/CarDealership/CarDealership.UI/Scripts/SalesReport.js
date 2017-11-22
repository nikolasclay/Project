$(document).ready(function () {

});

function search() {
	var id = $('#user').val();
	var from = $('#fromDate').val();
	var to = $('#toDate').val();

	$.ajax({
		type: 'GET',
		url: 'http://localhost:51989/api/sales/search/' + id + '/' + from + '/' + to,
		success: function (results) {
			$.each(results, function (index, sale) {

				var users = sale.user.firstname;
				var sales = sale.totalSales
				var vehicles = sale.totalVehicles;

				var row = '<div class="col-xs-9"<table><tr><th>User</th><th>Total Sales</th><th>Total Vehicles</th>'
				row += '<tr><td>' + users + '</td>'
				row += '<td>' + '$' + sales + '</td>'
				row += '<td>' + vehicles + '</td></tr>'
				row += '</table></div>'

				$('#searhResults').append(row);
			});
		},
		error: function () {

		}
	});
}
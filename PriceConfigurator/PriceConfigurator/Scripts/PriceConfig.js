$(document).ready(function () {
	$('.currentPrice').hide();
	$('.suggestedPrice').hide();
	$('#spHeader').hide();
	$('#cpHeader').hide();

});



$(document).ready(function () {
	$(".masterRow").click(function () {
		$('.currentPrice').hide();
		$('.suggestedPrice').hide();
		$(this).find(".currentPrice").css("background", "#ffffff");
		$(this).find(".currentPrice").show();
		$(this).find(".suggestedPrice").css("background", "#ffffff");
		$(this).find(".suggestedPrice").show();
		$('#spHeader').show();
		$('#cpHeader').show();

	});
});

$(document).ready(function(){
    getItems();
    findID();
    purchase();
    clearForms();

    
$('#addDollar').click(function(){
    var currentVal = $('#total').val();
    if (currentVal == "") {
        $('#total').val((1.00).toFixed(2));
    }
    else {
        $('#total').val((parseFloat(currentVal) + 1.00).toFixed(2));
    }
});
$('#addQuarter').click(function(){
    var currentVal = $('#total').val();
    if (currentVal == "") {
        $('#total').val((0.25).toFixed(2));
    }
    else {
        $('#total').val((parseFloat(currentVal) + 0.25).toFixed(2));
    }
});
$('#addDime').click(function(){
    var currentVal = $('#total').val();
    if (currentVal == "") {
        $('#total').val((0.10).toFixed(2));
    }
    else {
        $('#total').val((parseFloat(currentVal) + 0.10).toFixed(2));
    }
});
$('#addNickel').click(function(){
    var currentVal = $('#total').val();
    if (currentVal == "") {
        $('#total').val((0.05).toFixed(2));
    }
    else {
        $('#total').val((parseFloat(currentVal) + 0.05).toFixed(2));
    }
});

});

var item = $('#vendItems');

function getItems(){
    $.ajax({
        type: 'GET',
        url:'http://localhost:8080/items',
        success: function(itemArray){

            $.each(itemArray, function(index, product){
                var rows = $('#product' + product.id);

                var itemID = product.id;
                var name = product.name;
                var price = product.price;
                var quantity = product.quantity;

                
                var divRow = '<div class="col-md-4 items" id="menuItem" data-id=" ' + product.id + '">';
                divRow += '<button type = "button" class="btn btn-default style="padding-bottom:35px" id="itemButton">';
                divRow += '<p id="itemID">' + itemID + '</p>';
                divRow += '<p>' + name + '</p>';
                divRow += '<p>' + '$' + price + '</p>';
                divRow += '<p data-quantity="'+ product.quantity +'">' + 'Quantity Left: ' + quantity + '</p>' + '</div>';
                divRow +='</button>';
                item.append(divRow);
            });

            
        }
    });
}

function findID() {
    $('#vendItems').on('click', ".items", function () {
        var id = $(this).data("id");
        $('#item-Status1').val(id);
   });
}

function purchase(){

    $('#totalButton').click(function(){
        //check if value in item field is blank. If blank, send a message to the user
        if($('#item-Status1').val() == ""){

            $('#message').val().text("You must select an item.");
        }
        //call Ajax to vend an item. Assignment instructions provides the format for the URL
        else{
            $.ajax({

                Type: 'GET',
                url: 'http://localhost:8080/money/' + $('#total').val() + '/item/' + $('#item-Status1').val(), 
                success: function(changeDue){
                    $('#message').val('Purchase was successful.');

                    var moneyDiff = changeDue.quarters + ' quarters ' + changeDue.nickels + ' nickels ' + changeDue.dimes + ' dimes ';

                    $('#change-due').val(moneyDiff);
                },

                error: function(jqxhr){

                    $('#message').val(jqxhr.responseJSON.message);
                }

            })
        }

    })
}

function clearForms(){

    $('#getChange').click(function(){

        $('#form').trigger("reset");
    })
}


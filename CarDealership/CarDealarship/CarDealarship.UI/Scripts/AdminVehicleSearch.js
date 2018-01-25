
$('.details').hide();
$('#adminSearchButton').on('click', function () {
    var prams = {
        SearchKey: $('#SearchKey').val(),
        minPrice: $('#minPrice').val(),
        maxPrice: $('#maxPrice').val(),
        minYear: $('#minYear').val(),
        maxYear: $('#maxYear').val()
    };


    $.ajax({

        url: 'http://localhost:50163/api/Admin/Vehicle/',
        type: 'POST',
        data: JSON.stringify(prams),
        contentType: "application/json",
        success: function (vehicles) {
            var output = "";

            $.each(vehicles, function (index, value) {
                output += '<div class="row">'
                output += '<div class="col-md-3">'
                output += '<strong>' + value.Year + ' ' + value.MakeId.MakeName + ' ' +
                    value.ModelId.ModelName + '</strong><br/>' +
                    '<img src ="' + '/' + value.ImageFileName + '"width="100%" height= "100%" /></div>'
                output += '<div class="col-md-6">'
                output += '<table style="width=100%">'
                output += '<tr><td><strong>' + 'Body Style:' + '</strong>' + ' ' + value.VehicleType + '<br/>'
                    + '<strong>' + 'Trans:' + '</strong>' + value.Transmission + '<br/>'
                    + '<strong>' + 'Color:' + '</strong>' + value.Color + '</td>'
                output += '<td><strong>' + 'Interior:' + '</strong>' + value.Interior + '<br/>'
                    + '<strong>' + 'Mileage:' + '</strong>' + value.Mileage + '<br/>'
                    + '<strong>' + 'Vin:' + '</strong>' + value.VinNumber + '</td></div>'
                output += '<div class="col-md-3">'
                output += '<td><strong>' + 'Sales Price:' + '</strong>' + ' $' + value.SalesPrice + '<br/>'
                    + '<strong>' + 'MSRP:' + '</strong>' + value.MSRP + '<br/>'
                    + '<a class="btn btn-default" href="/Admin/EditVehicle/' + value.VehicleId + '">Edit</a></td></tr></table></div></div>'
            });

            $('#SearchResults').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {
        }

    });

});




function Purchase(id) {
    $('.searchItems').hide();
    $('#searchResultTitle').hide();
    $('#SearchResult').hide();
    $('.details').show();

    $.ajax({
        url: 'http://localhost:50163/api/Purchase/Sales/' + id,
        type: 'POST',
        success: function (value) {
            var output = "";
            output += '<div class="row">'
            output += '<div class="col-md-3">'
            output += '<strong>' + value.Year + ' ' + value.MakeId.MakeName + ' ' +
                value.ModelId.ModelName + '</strong><br/>' +
                '<img src ="' + '/' + value.ImageFileName + '"width="100%" height= "100%" /></div>'
            output += '<div class="col-md-3">'
            output += '<strong>' + 'Body Style:' + '</strong>' + ' ' + value.VehicleType + '<br/>'
                + '<strong>' + 'Trans:' + '</strong>' + value.Transmission + '<br/>'
                + '<strong>' + 'Color:' + '</strong>' + value.Color + '</div>'
            output += '<div class="col-md-3"><strong>' + 'Interior:' + '</strong>' + value.Interior + '<br/>'
                + '<strong>' + 'Mileage:' + '</strong>' + value.Mileage + '<br/>'
                + '<strong>' + 'Vin:' + '</strong>' + value.VinNumber + '</div>'
            output += '<div class="col-md-3">'
            output += '<strong>' + 'Sales Price:' + '</strong>' + ' $' + value.SalesPrice + '<br/>'
                + '<strong>' + 'MSRP:' + '</strong>' + value.MSRP + '<br/></div>'
            output += '<div class="col-md-12" id="desc"><strong>' + 'Description:' + '</strong>' + value.Description + '</div></div>'
            output += '<a href="http://localhost:50163/Home/Contact"><button class="submit" id="detailstocontactus" +  onclick="Details(' + value.VehicleId + ')">' + 'Contact Us' + '</button></a>'

            $('#detailsPage').html(output);
        }

    });

}

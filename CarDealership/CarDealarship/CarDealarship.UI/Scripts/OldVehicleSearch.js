
$('.details').hide();
$('#searchesButton').on('click', function () {
    var prams = {
        SearchKey: $('#SearchKey').val(),
        minPrice: $('#minPrice').val(),
        maxPrice: $('#maxPrice').val(),
        minYear: $('#minYear').val(),
        maxYear: $('#maxYear').val()
    };


    $.ajax({

        url: 'http://localhost:50163/api/SearchOdVehicle/SearchVehicle/',
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
                    + '<button class="submit" id="details" +  onclick="Details(' + value.VehicleId + ')">' + 'Details' + '</button></td></tr></table></div></div>'
            });

            $('#SearchResult').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {
        }

    });

});

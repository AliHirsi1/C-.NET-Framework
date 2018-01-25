$(document).ready(function () {
    getFeaturedVehicles();
    getSpecials();

});


// Get Featured Vehicles
function getFeaturedVehicles() {
    $.ajax({
        url: 'http://localhost:50163/api/vehicles/featured',
        type: 'GET',
        success: function (vehicles) {


            var output = "";

            for (var i = 0; i < vehicles.length; i++) {
                if (vehicles[i].IsFeatured) {

                    output += '<div class="col-xs-3"><img src="' + '/' + vehicles[i].ImageFileName + '"width="100%" height="100%" <br/>'
                    output += vehicles[i].Year + ' ' + vehicles[i].MakeId.MakeName + ' ' + vehicles[i].ModelId.ModelName + '<br/> '
                    output += '$' + vehicles[i].SalesPrice + '</div>'

                }
            }

            $('#featured').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    });
}


function getSpecials() {
    $.ajax({
        url: 'http://localhost:50163/api/vehicles/special',
        type: 'GET',
        success: function (specials) {

            var output = "";

            for (var i = 0; i < specials.length; i++) {

                output += '<div class=col-xs-12" style="height: 100%; width: 100%">'
                output += '<div class="col-xs-6" style="text-align:center">' + specials[i].Title + '</div><br/> '
                output += '<div class=col-xs-12">' + specials[i].Message + '</div></div></div>'


            }

            $('#specials').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    });
}





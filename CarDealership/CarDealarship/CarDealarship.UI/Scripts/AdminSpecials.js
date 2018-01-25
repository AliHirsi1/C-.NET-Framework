$(document).ready(function () {
    addminSpecials();


});
function addminSpecials() {
    $.ajax({
        url: 'http://localhost:50163/api/Specials/GetAllSpecials',
        type: 'GET',
        success: function (specials) {

            var output = "";

            for (var i = 0; i < specials.length; i++) {
                output += '<div>' + specials[i].Title
                output += '<button type="button" class="btn btn-danger">Delete</button><br/>'
                output += specials[i].Message + '</div>'
            }

            $('#specialplaceholder').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    });
}
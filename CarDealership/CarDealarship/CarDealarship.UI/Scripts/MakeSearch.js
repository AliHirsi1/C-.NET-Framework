$(document).ready(function () {
    getAllMakes();

});

function getAllMakes() {
    $.ajax({
        url: 'http://localhost:50163/api/Make/GetAllMakes',
        type: 'GET',
        success: function (makes) {
            var output = "";

            output += '<table>'
            output += '<th><td>' + 'Make' + '</td>'
            output += '<th><td>' + 'Date Added' + '<td>'
            output += '<th><td>' + 'User' + ' </th >'
            $.each(vehicles, function (index, value) {
                output += '<tr><td>' + value.MakeName + '</td>'
                output += '<td>' + value.Date + '</td>'
                output += '<td>' + value.user + '</td></tr></table>'
            }),
                $('#listOfMakes').html(output);

        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}
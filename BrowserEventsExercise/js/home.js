$(document).ready(function () {

    $('#pageContent').children().hide();
    $('#mainInfoDiv').show();

    $('#akronButton').on('click', function () {
        $('#pageContent').children().hide();
        $('#akronInfoDiv').toggle();
        $('#akronWeather').hide();

        $('#akronWeatherButton').on('click', function() {
            $('#akronWeather').toggle();
        });
    });


    $('#minneapolisButton').on('click', function () {
        $('#pageContent').children().hide();
        $('#minneapolisInfoDiv').show();
        $('#minneapolisWeather').toggle();

        $('#minneapolisWeatherButton').on('click', function() {
            $('#minneapolisWeather').toggle();
        });

    })


    $('#louisvilleButton').on('click', function () {

        $('#pageContent').children().hide();
        $('#louisvilleInfoDiv').show();
        $('#louisvilleWeather').toggle();

        $('#louisvilleWeatherButton').on('click', function () {
            $('#louisvilleWeather').toggle();
        });


    });

    $("tr").not(":first").hover(
        
        function () {
            $(this).css("background-color", "#f5f5f5");
        },
        // out callback
        function () {
            $(this).css("background-color", "");
        }
    );
    
});
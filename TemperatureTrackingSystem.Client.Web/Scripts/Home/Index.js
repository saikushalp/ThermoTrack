$(document).ready(function () {

    //Adding the minimum and maximum public functions to Array object using prototype
    Array.prototype.max = function () {
        return Math.max.apply(null, this);
    };

    Array.prototype.min = function () {
        return Math.min.apply(null, this);
    };

    var recievedTempData = [];
    var chart = new CanvasJS.Chart("chartContainer", {

        axisY: {
            title: "Temperature in Degrees",
            labelFormatter: function (e) {
                return e.value + "\u00B0C";
            }

        },
        axisX: {
            title: "Recorded Time",
        },
        toolTip: {
            contentFormatter: function (e) {
                return "Temperature at " + new Date(e.entries[0].dataPoint.x).toLocaleString() + " is " + e.entries[0].dataPoint.y + "\u00B0C";
            }
        },
        data: [{
            type: "splineArea",
            color: "#9CCFD7",
            markerSize: 5,
            dataPoints: recievedTempData
        }]
    });

    chart.render();

    //Set the hubs URL for the connection
    $.connection.hub.url = "http://localhost:8026/signalr";

    // Declare a proxy to reference the hub.
    var chat = $.connection.sensorHub;

    if (typeof chat === "undefined") {
        alert("Error occured while connecting to Sensor. Make sure Sensor application is running and try reloading the page");
    }

    // Create a function that the hub can respond to broadcast messages.
    chat.client.addMessage = function (temperature, recordedDateTime) {

        $('#gaugeDemo .gauge-arrow').css('transform', 'rotate(' + temperature + 'deg)');

        recievedTempData.push({
            x: new Date(recordedDateTime),
            y: temperature
        });

        //Remove the oldest array element in array to maintain historical data of last 20 records
        if (recievedTempData.length === 21) {
            recievedTempData.shift();
        }

        chart.render();
        $("#currentTemp").html(temperature + "&#176;C");
        $("#recordedDateTime").html(recordedDateTime);
        $("#minTemp").html(recievedTempData.map(a => a.y).min() + "&#176;C");
        $("#maxTemp").html(recievedTempData.map(a => a.y).max() + "&#176;C");
        $("#avgTemp").html((eval(recievedTempData.map(a => a.y).join("+")) / recievedTempData.length).toFixed(2) + "&#176;C");

    };

    // Start the connection.
    $.connection.hub.start();

});
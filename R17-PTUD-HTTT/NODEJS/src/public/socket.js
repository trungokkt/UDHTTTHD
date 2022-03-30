
$(function () {

    let connected = false;
    let shipperConnected = false;
    // set vi tri sau 10s
    // setInterval(function () {
    //     if (shipperConnected == true) {
    //         localStorage.removeItem('position-shipper');
    //         localStorage.removeItem('address-shipper');
    //         console.log('run')
    //         getLocation();
    //     }
    // }, 10000);
    const socket = io();
    socket.on('connect', () => {
        connected = true;
        socket.emit('join room');
    });
    socket.on('revicing order', (order) => {
        $("#myTable").prepend(`
        <tr>
            <td><button class="btn">choose this</button></td>
            <td style="text-align: center; vertical-align: middle;">${order.orderId}</td>
            <td style="text-align: center; vertical-align: middle;">${order.orderPrice}</td>
            <td style="text-align: center; vertical-align: middle;">${order.orderAddress}</td>
            <td style="text-align: center; vertical-align: middle;">${order.orderPhone}</td>
        </tr>
        `);
    })
    socket.on('check shipper', (data) => {
        if (data == true) {
            shipperConnected = true
        }
    })
    
    $("#orderForm").submit(function (e) {
        e.preventDefault(); // avoid to execute the actual submit of the form.
        var form = $(this);
        // var formdata = form.serializeArray();
        // var data = {};
        // $(formdata ).each(function(index, obj){
        //     data[obj.name] = obj.value;
        // });
        $.ajax({
            type: "POST",
            url: "/api/order",
            data: form.serialize(), // serializes the form's elements.
            success: function(data)
            {
                console.log(data)
                socket.emit('send order', data);
                window.location.href = '/user/order'; 
            }
        });
    });
    function getDistanceFromLatLonInKm(lat1, lon1, lat2, lon2) {
        var R = 6371; // Radius of the earth in km
        var dLat = deg2rad(lat2 - lat1);  // deg2rad below
        var dLon = deg2rad(lon2 - lon1);
        var a =
            Math.sin(dLat / 2) * Math.sin(dLat / 2) +
            Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
            Math.sin(dLon / 2) * Math.sin(dLon / 2)
            ;
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c; // Distance in km
        return d;
    }
    function deg2rad(deg) {
        return deg * (Math.PI / 180)
    }
});





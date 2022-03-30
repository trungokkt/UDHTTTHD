$(document).ready(function () {
    $.ajax({
      url: "https://localhost:44357/api/products/del",
      type: "get",
      success: function (result) {
        result.forEach((element) => {
          $("#body-table").append(` <tr>
          <td>${element.productName}</td>
          <td>${element.productDescription}</td>
          <td>${element.productPrice}</td>
          <td>${element.productInventory}</td>
          <td>${element.productTypeId}</td>
          <td><button  class="btn btn-primary abc" product =${element.productId}>Restore</button></td>
       
        </tr>`);
        });
         console.log(result);
         $("button.abc").on("click", function (e) {
          const id =$(this).attr('product');
          $.ajax({
           url: "https://localhost:44357/api/products/restore/"+id,
           type: "post",
           success: function (result) {
             console.log(result);
             location.href = "/products/del";
           },
           error: function (xhr, status, err) {
             console.log({xhr, status, err});
         if (err == "No conversion from text to application/json") location.href = "/products";
           },
   
         
         
         
         });
           
         });
      },
      error: function (xhr, status, err) {},
    });
    // $("#my-form").submit((e) => {
    //   e.preventDefault();
    //   // location.href = ""
    //   //Call API
    //   $.ajax({
    //     url: "https://jsonplaceholder.typicode.com/posts",
    //     type: "get",
    //     // cache: true,
    //     // data: JSON.stringify({
    //     //   title: $("#word").val(),
    //     //   body: "bar",
    //     //   userId: 1,
    //     // }),
    //     // headers: {
    //     //   "Content-type": "application/json; charset=UTF-8",
    //     // },
    //     success: function (result) {
    //       console.log(result[0]);
    //       $("#content").append(`<h1><a>${result[0].body}</a></h1>`);
    //     },
    //     error: function (xhr, status, err) {
    //       console.log({ xhr, status, err });
    //     },
    //   });
    // });
  });
  
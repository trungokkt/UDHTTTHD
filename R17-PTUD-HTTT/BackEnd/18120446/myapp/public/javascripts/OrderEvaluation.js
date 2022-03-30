$(document).ready(function (){ 
    
    $.ajax({
      url: "https://localhost:44357/api/OrderEvaluations",
      type: "get",
      success: function (result) {
        result.forEach((element) => {
          $("#body-table").append(` <tr>
          <td>${element.orderId}</td>
          <td>${element.userId}</td>
          <td>${element.evaluation}</td>
          <td>${element.evaluationDate}</td>
          
        </tr>`);
        });
         console.log(result);
      },
      
      error: function (xhr, status, err) {},
  
      
  
  
    });
   
    
  
  
  });
  
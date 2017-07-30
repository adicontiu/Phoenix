<?php

//echo "string";

$con=mysqli_connect("localhost","root","","medicalhack");
if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }

 $query="SELECT * from orders, seller WHERE orders.pin=seller.pin ORDER BY orders.id DESC";

 if($result=mysqli_query($con,$query))
 {
 	while($row=mysqli_fetch_array($result,MYSQLI_ASSOC))
 		{
 			echo $row['id']."/".$row['customername']."/".$row['phone']."/".$row['pin']."/".$row['address']."/".$row['medicine']."/";
 			break;
 		};


 }
 else
 	echo mysqli_error($con);


 ?>
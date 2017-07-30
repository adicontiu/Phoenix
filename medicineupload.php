<?php

$con=mysqli_connect("localhost","root","","medicalhack");
if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }

//echo "2";

if(!empty($_POST['fullName'])&&!empty($_POST['mobile'])&&!empty($_POST['pin'])&&!empty($_POST['add'])&&!empty($_POST['medi']))
{


	$name=$_POST['fullName'];
	$phone=$_POST['mobile'];	
	$address=$_POST['add'];
	$pin=$_POST['pin'];
	$medi=$_POST['medi'];
	//$time=date();



$qry="INSERT into orders (customername,phone, address,pin,medicine) VALUES('".$name."','".$phone."','".$address."','".$pin."','".$medi."')";

	//$qry="INSERT into orders VALUES('hello','hello','hello','hello','hello')";



if(mysqli_query($con,$qry))
 	echo "1";
 else 

 	echo mysqli_error($con);

 }



 // $qry="INSERT into orders VALUES('hello','hello','hello','hello','hello')";
 // mysqli_query($con,$qry);

// else
//  echo"2";

//Error code:
//1:Sucess
//2:Emty fields;





?>
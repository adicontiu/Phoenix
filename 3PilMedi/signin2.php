<?php
$con=mysqli_connect("localhost","root","","medicalhack");
if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  
  }


  if(!empty($_POST['UserName'])&&!empty($_POST['_password'])){


  	$email=$_POST['UserName'];
	$password=$_POST['_password'];

$sql1="SELECT email FROM users where email='".$email."' and password='".$password."'";

		if ($data=mysqli_query($con,$sql1)) {
	if(mysqli_num_rows($data)==1)
	    echo "sucess";
	else
		echo tos"2";

  }

}

  else
  	echo "Empty";
 

//Error codes
  //0: database error
  //1:Sucessfull login
  //2:authentication failed
  //5:Fill all fields

  ?>


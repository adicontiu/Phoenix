<?php
//require('connect.php');
$con=mysqli_connect("localhost","root","","medicalhack");
if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }

if(!empty($_POST['fullName'])&&!empty($_POST['password'])&&!empty($_POST['add'])&&!empty($_POST['DOB'])&&!empty($_POST['email'])){
$name=$_POST['fullName'];
$password=$_POST['password'];
 $add=$_POST['add'];
 $gen=$_POST['sex'];
 $phone=$_POST['DOB'];
 $email=$_POST['email'];
 
   $bool=$_POST['Bool'];



 if($bool=="0"){
 
 
  $sql1="SELECT email FROM users where email='".$email."'";
 
 if ($data=mysqli_query($con,$sql1)) {
 	if(mysqli_num_rows($data)==0){
 
 
 
  $sql = "INSERT INTO users (Name, email,password,address,phone,gender)
 VALUES ('".$name."', '".$email."','".$password."','".$add."','".$phone."','".$gen."')";
 
if (mysqli_query($con,$sql) === TRUE) {
    echo "1";
} else {
    echo "2";
}
}
else echo"3";
}
else echo "4";
}

else{	$sql1="SELECT email FROM seller where email='".$email."'";
		if ($data=mysqli_query($con,$sql1)) {
				 	if(mysqli_num_rows($data)==0){
				 
				 
				 
				  $sql = "INSERT INTO seller (sellername, email,password,mobile,address,pin)
				 VALUES ('".$name."', '".$email."','".$password."','".$phone."','".$add."','".$gen."')";
				 
				if (mysqli_query($con,$sql) === TRUE) {
				    echo "1";
				} else {
				    echo "2";
				}
				}
				else echo"3";
				}
				else
					echo "4";


}


}
else
    echo "5";

 //code
 //1: SUcessful
 //2:error
 //3:Email already exists
 //4:Erroe
 //5: fill all fields 
?>

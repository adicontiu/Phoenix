<?php
//require('connect.php');
$con=mysqli_connect("localhost","root","","medicalhack");
if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }

if(!empty($_POST['UserName'])&&!empty($_POST['_password'])){


  	$email=$_POST['UserName'];
	$password=$_POST['_password'];
	//$bool=$_POST['Bool'];


	
		$sql1="SELECT email FROM users where email='".$email."' and password='".$password."'";
	
			if ($data=mysqli_query($con,$sql1)) {
				if(mysqli_num_rows($data)==1)
		    		echo "1";
				// else
				// 	echo "3";
			}
		
			else
				{
				$sql1="SELECT email FROM seller where email='".$email."' and password='".$password."'";
	
					if ($data=mysqli_query($con,$sql1)) {
						if(mysqli_num_rows($data)==1)
		    			echo "1";
					else
						echo "3";
					}


  	}

	
}
else

echo"Empty";
  ?>

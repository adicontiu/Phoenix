<?php
echo phpinfo();

ini_set("SMTP","ssl://smtp.gmail.com");
ini_set("smtp_port","465");


$to = "somebody@example.com";
$subject = "My subject";
$txt = "Hello world!";
$headers = "From: webmaster@example.com" . "\r\n" .
"CC: somebodyelse@example.com";

mail($to,$subject,$txt,$headers);
?>

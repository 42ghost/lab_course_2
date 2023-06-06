<?php
	$users = file_get_contents("db.json");
	$users = json_decode($users, true);
	$name = $_GET["login"];
	
	if ($users[$name]){
		$new_pass = "";
		$alphabet = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUWXYZ0123456789";
		for ($i = 0; $i < 8; $i++) {
		    $n = rand(0, 60);
		    $new_pass = $new_pass.$alphabet[$n];
		}
		
		$users[$name]["passwd"] = md5($new_pass.$name);
		$users[$name]["passwd_exp_date"] = time() + 60 * 10;
		$newUsers = json_encode($users);
		file_put_contents('db.json', $newUsers);
		
		#print($new_pass);

		header("Location: http://lab.local/login.php?msg="."New password is ".$new_pass);
		exit();
	}else{
		header("Location: http://lab.local/forgot_password.php?msg="."Login doesn't exist");
		exit();
	}
?>

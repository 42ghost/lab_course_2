<?php
	#Проверка настроены ли куки в каждом файле
	$users = file_get_contents("db.json");
	$users = json_decode($users, true);
	
	$name = $_COOKIE['user'];
	if($users[$name]["passwd"] != md5($_GET["old_password"].$name)){
		$msg = "Error: Wrong password";
		header("Location: http://lab.local/change_passwd.php?msg=".$msg);
		exit();
	}

	$pswd = $_GET["new_password"];
	
	if($users[$name]["passwd"] == md5($pswd.$name)){
		$msg = "ERROR: Identical passwords";
		header("Location: http://lab.local/change_passwd.php?msg=".$msg);
		exit();
	}elseif(strlen($pswd) < 6 && strlen($pswd) > 24){
		$msg = "ERROR: Invalid new password length";
		header("Location: http://lab.local/change_passwd.php?msg=".$msg);
		exit();
	}
	
	print_r($users[$name]);
	$users[$name]["passwd"] = md5($pswd.$name);
	$users[$name]["passwd_exp_date"] = time() + 60 * 10;
	$newUsers = json_encode($users);
	file_put_contents('db.json', $newUsers);
	
	header("Location: http://lab.local/index.php");
	exit();
?>

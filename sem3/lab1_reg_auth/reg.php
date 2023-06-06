<?php
	$msg = "";
	$login = $_GET["login"];
	$pswd = $_GET["password"];
	
	$users = file_get_contents("db.json");
	$users = json_decode($users, true);
	
	if ($users[$login]){
		$msg = "ERROR: Login exists";
		header("Location: http://lab.local/signup.php?msg=".$msg);
		exit();
	}elseif (empty($_GET["login"])){
		$msg = "ERROR: Login is empty";
		header("Location: http://lab.local/signup.php?msg=".$msg);
		exit();
	}elseif(strlen($login) < 3 || !preg_match("#^[a-z0-9]+$#i", $login)){
		$msg = "Error: Login is incorrect (only a-z and 0-9)";
		header("Location: http://lab.local/signup.php?msg=".$msg);
		exit();
	}elseif(empty($_GET["password"])){
		$msg = "ERROR: Password is empty";
		header("Location: http://lab.local/signup.php?msg=".$msg);
		exit();
	}elseif(strlen($_GET["password"]) < 6 || strlen($_GET["password"]) > 30){
		$msg = "ERROR: Invalid length of password";
		header("Location: http://lab.local/signup.php?msg=".$msg);
		exit();
	}elseif(!preg_match("#^[a-z0-9]+$#i", $pswd)){
		$msg = "ERROR: Password is incorrect";
		header("Location: http://lab.local/signup.php?msg=".$msg);
		exit();
	}else
	{	
		if ($users[$login]){
				$msg = "User with this login is already registered";
				header("Location: http://lab.local/signup.php?msg=".$msg);
				exit();
			}
		
		$new_user["passwd"] = md5($pswd.$login);
		$new_user["passwd_exp_date"] = time() + 60 * 10;
		
		$users[$login] = $new_user;
		file_put_contents("db.json", json_encode($users));
		
		header("Location: auth.php?login=".$login."&password=".$pswd);
		exit();
	}
?>















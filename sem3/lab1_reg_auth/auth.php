<?php
	$users = file_get_contents("db.json");
	$users = json_decode($users, true);
	$user = $_GET["login"];
	
	if ($users[$user] != ""){
		if ($users[$user]["passwd"] == md5($_GET["password"].$_GET["login"]))
		{
			if (isset($_COOKIE["token"])){
				header("Location: http://lab.local/index.php?user=".$user);
				exit();
			}
			else{
				setcookie("token", random_bytes(15), time() + 3600);
				setcookie("user", $user, time() + 3600);
				header("Location: http://lab.local/index.php?user=".$user);
				exit();
			}
		}else{
			$msg = "Error: Wrong password";
			header("Location: http://lab.local/login.php?msg=".$msg);
			exit();
		}
	}
	else{
		$msg = "Error: User with this login does not exist";
		header("Location: http://lab.local/login.php?msg=".$msg);
		exit();
	}
?>

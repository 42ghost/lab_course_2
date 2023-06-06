<!DOCTYPE>
<html>

	<head>
	<title> Main page </title>
	</head>
	
	<?php
		if (!(isset($_COOKIE["token"]))) {
			header("Location: http://lab.local/signup.php");
		}
	?>

	<body>
		
		<p>&shy; &shy;</p>
		<p>&shy; &shy;</p>
		
		<h1 align="center">
		<?php
			$name = "";
			if (isset($_GET["user"]))
				$name = ", ".$_GET["user"];
			else if (isset($_COOKIE["user"]))
				$name = ", ".$_COOKIE["user"];
			print("Hello{$name}!");
		?>
		</h1>
		<div  align="center">
		<table>
			<td>
			<form method="" action="change_passwd.php">
				<button>Change password</button>
			</form>
			</td>
			<td>
			<form method="" action="login.php">
				<button>Log out</button>
			</form>
			</td>
		</table>
		</div>
	</body>
</html>

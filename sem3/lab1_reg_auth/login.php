<!DOCTYPE>
<html>

	<head>
	<title> Log in </title>
	</head>
	<body vlink="#0000ff">
		<p>&shy; &shy;</p>
		<p>&shy; &shy;</p>
		<h1 align="center">Log in</h1>
        <h5 align=center style = "color:red">
			<?php
				unset($_COOKIE['token']);
				unset($_COOKIE['user']);
				print($_GET["msg"]);
			?>
        </h5>
		<form method="GET" action="auth.php">
		<table align="center">
			<tr>
				<td>
				<label>Login</label>
				</td>
				<td>
				<input type="text" name="login" placeholder="Login"/>
				</td>
			</tr>
			<tr>
				<td>
				<label>Password</label>
				</td>
				<td>
				<input type="password" name="password" placeholder="Password">
				</td>
			</tr>
			<tr>
				<td></td>
				<td align="right">
					<font size="2"><a href="forgot_password.php">Forgot your password?</a></font>
				</td>
			</tr>
			<tr>
				<td></td>
				<td align="center">
				<button type="submit"> <font size="3">Log in</font> </button>
				</td>
			</tr>
		</table>
		</form>
		
		<p>&shy; &shy;</p>
		<p>&shy; &shy;</p>
				
		<form method="" action="signup.php">
		<table align="center">
			<tr>
				<td>Don’t have an account?</td>
				<td align="center">
				<button> <font size="3">Join now</font>  </button>
				</td>
			</tr>
		</table>
		</form>
	</body>
</html>










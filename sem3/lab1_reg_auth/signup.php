<!DOCTYPE>
<html>

	<head>
	<title> sign in </title>
	</head>
	<body vlink="#0000ff">
		<p>&shy; &shy;</p>
		<p>&shy; &shy;</p>
		<h1 align="center">Register</h1>
		
        <h5 align=center style = "color:red">
			<?php
				print($_GET["msg"]);
			?>
        </h5>
		<form method="GET" action="reg.php">
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
					<font size="2"><a href="login.php">Already have an account?</a></font>
				</td>
			</tr>
			<tr>
				<td></td>
				<td align="center">
				<button type="submit"> <font size="3">Sign in</font> </button>
				</td>
			</tr>
		</table>
		</form>
	</body>
</html>









<!DOCTYPE>
<html>
	<!--кнопка назад-->
	<head>
		<title> Change password </title>
	</head>
	<body vlink="#0000ff">
		<p>&shy; &shy;</p>
		<p>&shy; &shy;</p>
		<h1 align="center">Change password</h1>
        <h5 align=center style = "color:red">
			<?php
				print($_GET["msg"]);
			?>
        </h5>
		<form method="GET" action="chg_pw.php">
		<table align="center">
			<tr>
				<td>
				<label> old password </label>
				</td>
				<td>
				<input type="password" name="old_password" placeholder="old password"/>
				</td>
			</tr>
			<tr>
				<td>
				<label>new password</label>
				</td>
				<td>
				<input type="password" name="new_password" placeholder="new password">
				</td>
			</tr>
			<tr>
				<td></td>
				<td align="right">
					<!-- Добавить работоспособность -->
					<font size="2"><a href="index.php">back</a></font>
				</td>
			</tr>
			<tr>
				<td></td>
				<td align="center">
				<button type="submit"> <font size="3">Change</font> </button>
				</td>
			</tr>
		</table>
		</form>
	</body>
</html>

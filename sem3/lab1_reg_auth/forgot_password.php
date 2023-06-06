<!DOCTYPE>
<html>

	<head>
	<title> Password recovery </title>
	</head>
	<body vlink="#0000ff">
		<p>&shy; &shy;</p>
		<p>&shy; &shy;</p>
		<h2 align="center">Password recovery</h2>
		<h4 align=center style = "color:red">
			<?php
				print($_GET["msg"]);
			?>
        </h4>
        <form method="GET" action="recovery_paswd.php">
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
				<td></td>
				<td align="right">
					<font size="2"><a href="login.php">back</a></font>
				</td>
			</tr>
		    <tr align="center">
		    	<td></td>
		    	<td align="center">
					<button type="submit"> <font size="3"> Confirm it's you </font> </button>
				</td>
			</tr>
			</tabel>
		</form>
	</body>
</html>










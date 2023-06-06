<tr>
<td>
	<form action="add_comm.php" method="POST">
		<input type="text" name="subcomm" placeholder="answer...">
		<input type="hidden" name="comment_id" value="<?php echo $comments_list[$i]["id"]?>">
		<input type="hidden" name="page"  value="<?php echo $_GET["page"]?>"> 
		<button type="submit">Comment</button>
	</form>
</td>
</tr>

<tr>
<td>
	<?php
		$comm_id = $comments_list[$i]["id"];
		
		$con = mysqli_connect("localhost", "root", "", "posts");
		$sql = "SELECT * FROM sub_comments WHERE comment_id=$comm_id ORDER BY `id` ASC";
		$subcomm_list = mysqli_query($con, $sql);
		$subcomm_amnt = mysqli_num_rows($subcomm_list);
		$subcomm_list = mysqli_fetch_all($subcomm_list, MYSQLI_ASSOC);
		for ($j = 0; $j < $subcomm_amnt; $j++){
			echo "<tr><td>";
			echo "&nbsp;&nbsp;&nbsp;ans. ".$j.":&nbsp;&nbsp;&nbsp;".$subcomm_list[$j]["text"];
			echo "</td></tr>";
		}
	?>
</td>
</tr>

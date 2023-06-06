<tr>
<td>
	<form action="add_comm.php" method="POST">
		<input type="text" name="comm" placeholder="Comment...">
		<input type="hidden" name="note_id" value="<?php echo $note_list[$id]["id"]?>">
		<input type="hidden" name="page"  value="<?php echo $_GET["page"]?>"> 
		<button type="submit">Comment</button>
	</form>
</td>
</tr>

<tr>
<td>
	<?php		
		$note_id = $note_list[$id]['id'];
		$con = mysqli_connect("localhost", "root", "", "posts");
		$sql = "SELECT * FROM comments WHERE note_id=$note_id ORDER BY `id` ASC";
		$comments_list = mysqli_query($con, $sql);
		$comm_amnt = mysqli_num_rows($comments_list);
		$comments_list = mysqli_fetch_all($comments_list, MYSQLI_ASSOC);
		mysqli_close($con);
		for ($i = 0; $i < $comm_amnt; $i++){
			echo "<tr><td bgcolor='B19494'>";
			echo "comment ".$i.": ".$comments_list[$i]['text'];
			echo "</td></tr>";

			#$comments_list
			include "includes/subcomments.php";
			echo "<td>----------------------------------------------------</td>";
			echo "<tr height=5><tr>";
		}
	?>
</td>
</tr>

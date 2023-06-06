# Лабораторная работа "Анонимный форум"
*****
## Цель работы
Разработать и реализовать клиент-серверную информационную систему реализующую механизм CRUD
## Задание
Система предназначена для анонимного общения в сети интернет.
Интерфейс системы представляет собой веб-страницу с лентой заметок, отсортриованных в обратном хронологическом порядке и форму добавления новой заметки. В ленте отображается последние 100 заметок

### Возможности пользователей:
* добавление текстовых заметок в общую ленту
* реагирование на чужие заметки (лайки)
### Дополнительные опции:
* добавление комментариев к чужим заметкам
* "раскрывающиеся комментарии"
* Реакции разных видов (лайк/дизлайк)
* Добавление изображений к заметкам
* Комментирование второго уровня
## Ход работы
### Пользовательский интерфейс
*Главная страница

![Рис. 1 - Интерфейс](https://github.com/4260snow/lab_forum/blob/main/images/ui.png)
### Сценарии работы
Возможные сценарии:
* Добавление новой записи (в том числе и записи с картинкой). Пользователь не может добавить запись без текста
![Рис.2 - Сценарий "новой записи"](https://github.com/4260snow/lab_forum/blob/main/images/add_note.png)

* Реакция на опубликованные ранее записи: При нажатии пользователем на 1 из 3 реакций (лайк/безразличие/дизлайк), её число увеличивается (информация в бд обновляется).Пользователь способен поставить неограниченное число каждой реакций.
* Комментирование записей и ответ, ранее написанным, комметариям: Нажав на кнопку "Show comments" перед пользователем "разворачиваются" ранее написанные комментарии и ответы на них, отсортированные в хронологическом порядке. Пользователь может ввести в поле "Comment" текст нового комментария и опубликовать его, нажав на кнопку "Comment". Также есть возможность ответить на каждый комментарий, введя текст в поле "Answer" и нажав на кнопку "Comment" рядом с ним. При нажатии на кнопку комментарий/ответ на комментарий записывается в БД и страница обновляется. При этом пользователь остаётся на странице с тем же номером.
* Перемещение по страницам форума к более ранним записям: Внизу страниы есть 2 кнопки. "prev" и "next". "prev" осуществляет переход к началу форума - к последним записям (ограничено нулевой страницей). "next" - переход к ранним публикациям (ограничено числом всех записей делёным на количество записей на 1 странице)

## Описание client-server
* Создание новой записи

![Рис.3 - client-server новая запись](https://github.com/4260snow/lab_forum/blob/main/images/cl_serv_1.svg)

* Реакция на запись

![Рис.4 - client-server реакция](https://github.com/4260snow/lab_forum/blob/main/images/reactions.svg)

* Комментарий

![Рис.5 - client-server комментирование](https://github.com/4260snow/lab_forum/blob/main/images/comments.svg)

* Переход по страницам

![Рис.6 - client-server переход по страницам](https://github.com/4260snow/lab_forum/blob/main/images/pagenation.svg)


## Структура базы данных MySQL
Для хранения данных используется MySQL.Которая содержит 3 таблицы: записи, комментарии, ответы на комментарии.
* Таблица с записями. Содержит: id записи, текс записи, время, количество реакций, наличие картинки.

```sh
{
    "id" (int A_I): 21,
    "text" (tinytext): "fire",
    "likes" (int): 4,
    "dislikes" (int): 1,
    "indifference" (int): 0,
    "time": 2022-12-23 19:53:40,
    "picture": 1
}
```

* Таблица комментариев: id комментария, текст комментария, id записи, к которой относится этот комментарий
```sh
{
    "id" (int A_I): 3,
    "text" (tinytext): "text3",
    "note_id" (int unsigned): 27,
}
```
* Таблица ответов: id ответа, текст ответа, id комментария, к которой относится этот ответ
```sh
{
    "id": 2,
    "text": "sub",
    "comment_id": 27,
}
```

## Алгоритмы
* Отображение записей

![Рис.7 Отображение записей](https://github.com/4260snow/lab_forum/blob/main/images/view.svg)

* Добавление записи

![Рис.8 Добавление записи](https://github.com/4260snow/lab_forum/blob/main/images/add_note_bs.svg)

* Добавление комментариев

![Рис.9 Добавление комментариев](https://github.com/4260snow/lab_forum/blob/main/images/comment_bs.svg)

* Реакции на записи

![Рис.10 Реакции на записи](https://github.com/4260snow/lab_forum/blob/main/images/reactions_bs.svg)

* Переход по страницам

![Рис.11 Переход по страницам](https://github.com/4260snow/lab_forum/blob/main/images/page_bs.svg)

## Значимые фрагменты кода
* Цикл отображения записей
```sh
<?php 
    $N = 10; $page_num = $_GET["page"];

    if ($notes_amnt % 10 && $page_num == round($notes_amnt / $N))
        $N = $notes_amnt % 10;

    for ($id = $N * $page_num; $id < $N * ($page_num + 1); $id++)
    {
        include ("includes/note.php");
        if ($id + 1 == $notes_amnt)
        {
            break;
        }
    }
?>
```

* Получение сиска записей из бд
```sh
<?php

	$con = mysqli_connect("localhost", "root", "", "posts");
	if (!$con)
	{
		die("Connection failed: ".mysqli_connect_error());
	}
	
	mysqli_set_charset($con, "utf8");

	$sql = "SELECT * FROM posts ORDER BY time DESC";
	
	
	$info = mysqli_query($con, $sql);
	$notes_amnt = mysqli_num_rows($info);
	$note_list = mysqli_fetch_all($info, MYSQLI_ASSOC);
	
	mysqli_close($con);
?>
```

* Добавление новой записи в бд
```sh
    $con = mysqli_connect("localhost", "root", "", "posts");			
    $allowed_types = array("image/jpeg", "image/jpg");
    if ($_FILES["image"]["error"] == 0)
    {
        $name = $_POST["id"] . '.jpg';
        copy($_FILES["image"]["tmp_name"], "images/".$name);

        $sql = "INSERT INTO `$table` (`text`, `picture`) VALUES ('$text', '1')";
        mysqli_query($con, $sql);
    }
    else
    {
        $sql = "INSERT INTO `$table` (`text`) VALUES ('$text')";
        mysqli_query($con, $sql);
    }
    header("Location: http://lab.local/index.php");
```

* Показать/скрыть комментарии
```sh
<script> 
	function show(id){
		let comm = document.getElementById("comm"+id);
		if (comm.getAttribute("hidden")){
			comm.removeAttribute("hidden");
		}else{
			comm.setAttribute("hidden", true);
		}
	}
</script>
...
#code
...
<button id=<?php echo $id ?> onclick="show(<?php echo $id ?>)">Show comments</button>
```

* Переход между страницами
```sh
<?php
	function prevPage(){
		if ($_POST["page"] > 0){
			$newPage = $_POST["page"] - 1;
			header('Location: http://lab.local/index.php?page=' . $newPage);
		}
	}

	function nextPage(){
		#SQL проверка
		$newPage = $_POST["page"] + 1;
		header('Location: http://lab.local/index.php?page=' . $newPage);
	}
	
	if($_POST["btn"] == "prev"){
		prevPage();
	}else if ($_POST["btn"] == "next"){
		nextPage();
	}
?>
```

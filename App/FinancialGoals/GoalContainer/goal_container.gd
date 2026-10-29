extends Panel

@onready var goal: RichTextLabel = $DescriptionContainer/Goal

func set_goal_text(text : String) -> void:
	goal.text = text;

func _on_button_pressed() -> void:
	call_deferred("queue_free");

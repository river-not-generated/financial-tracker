extends Control


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
@onready var label: RichTextLabel = $Label
func _process(delta: float) -> void:
	global_position.x = LerpHelper.lf(global_position.x, 0, 2.0, delta)

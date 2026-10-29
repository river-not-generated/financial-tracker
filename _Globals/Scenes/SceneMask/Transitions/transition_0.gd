extends SceneTransition


@onready var anchor: Node2D = $Anchor
@onready var diamond: ColorRect = $Anchor/Diamond

func _ready() -> void:
	$Anchor/Diamond.color.a = 0.333
	$Anchor.scale = Vector2(0.001, 0.001)


func fade_out(tween: Tween, time_mult := 1.0) -> void:
	anchor.rotation = 4.0
	anchor.scale = Vector2(4, 4)
	diamond.color.a = 1.0
	
	tween.tween_property(anchor, "rotation", -4.0, time*time_mult)
	tween.parallel().tween_property(anchor, "scale", Vector2(0.001, 0.001), time*time_mult)
	tween.parallel().tween_property(diamond, "color:a", 0.333, time*time_mult)

func fade_in(tween: Tween, time_mult := 0.5) -> void:
	anchor.rotation = 0.0
	anchor.scale = Vector2(0.001, 0.001)
	diamond.color.a = 0.333
	
	tween.tween_property(anchor, "rotation", 4.0, time*time_mult)
	tween.parallel().tween_property(anchor, "scale", Vector2(4, 4), time*time_mult)
	tween.parallel().tween_property(diamond, "color:a", 1.0, time*time_mult)

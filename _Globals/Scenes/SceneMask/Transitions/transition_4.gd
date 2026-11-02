extends SceneTransition


@onready var anchor: Node2D = $Anchor
func fade_out(tween: Tween, time_mult := 1.0) -> void:
	anchor.position.y = 324.0
	
	tween.tween_property(anchor, "position:y", -324.0, time*time_mult).set_trans(Tween.TRANS_ELASTIC)

func fade_in(tween: Tween, time_mult := 1.0) -> void:
	anchor.position.y = -324.0
	
	tween.tween_property(anchor, "position:y", 324.0, time*time_mult).set_trans(Tween.TRANS_ELASTIC)

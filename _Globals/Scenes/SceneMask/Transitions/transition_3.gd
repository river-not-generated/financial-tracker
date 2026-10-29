extends SceneTransition

@onready var pillars_top: Control = $PillarsTop
@onready var pillars_bottom: Control = $PillarsBottom

func fade_in(tween: Tween, time_mult := 1.0) -> void:
	pillars_top.position.y = 648.0
	pillars_bottom.position.y = -648.0
	modulate.a = 0.0
	
	tween.tween_property(pillars_top, "position:y", 0.0, time*time_mult).set_trans(Tween.TRANS_EXPO)
	tween.parallel().tween_property(pillars_bottom, "position:y", 0.0, time*time_mult).set_trans(Tween.TRANS_EXPO)
	tween.parallel().tween_property(self, "modulate:a", 1.0, time*time_mult)

func fade_out(tween: Tween, time_mult := 1.0) -> void:
	pillars_top.position.y = 0.0
	pillars_bottom.position.y = 0.0
	modulate.a = 1.0
	
	tween.tween_property(pillars_top, "position:y", 648.0, time*time_mult).set_trans(Tween.TRANS_EXPO)
	tween.parallel().tween_property(pillars_bottom, "position:y", -648.0, time*time_mult).set_trans(Tween.TRANS_EXPO)
	tween.parallel().tween_property(self, "modulate:a", 0.0, time*time_mult)

extends Panel

@onready var amount: RichTextLabel = $Amount
@onready var description: RichTextLabel = $DescriptionContainer/Description

func SetDescription(desc : String) -> void:
	description.text = desc;
	
func SetAmount(amnt : float) -> void:
	amount.text = "$" + str(amnt);
	
func SetValues(amnt: float, desc : String) -> void:
	SetDescription(desc);
	SetAmount(amnt);

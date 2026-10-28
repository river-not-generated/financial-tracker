extends Panel

@onready var amount: RichTextLabel = $Amount
@onready var description: RichTextLabel = $DescriptionContainer/Description
@onready var date_text: RichTextLabel = $Date

func SetDate(date : String) -> void:
	date_text.text = date;

func SetDescription(desc : String) -> void:
	description.text = desc;
	
func SetAmount(amnt : float) -> void:
	amount.text = "$" + str(amnt);
	
func SetValues(amnt: float, desc : String, date: String) -> void:
	SetDescription(desc);
	SetAmount(amnt);
	SetDate(date);

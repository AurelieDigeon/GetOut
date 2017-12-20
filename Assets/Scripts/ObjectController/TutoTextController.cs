using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutoTextController : InteractionBase {

	private TextMesh textMesh;

	private AudioSource audio;

	public string InitMessage;
	public string GoalMessage;
	public string HaloMessage;
	public string ObserveMessage;
	public string UseMessage;
	public string TakeMessage;
	public string BeginGameMessage;

	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
		audio = GetComponent<AudioSource> ();
		StartTuto();
	}

	public void StartTuto() {
		textMesh.text = InitMessage.Replace("\\n","\n");
		//On commence le tuto, on peut observer la télé
		availableInteractions.Add (InteractionType.Observe, new UnityAction (GoalTuto));
	}
		
	public void GoalTuto() {
		textMesh.text = GoalMessage.Replace("\\n","\n");
		availableInteractions [InteractionType.Observe] = new UnityAction (HaloTuto);
		audio.Play ();
	}

	public void HaloTuto() {
		textMesh.text = HaloMessage.Replace("\\n","\n");
		availableInteractions [InteractionType.Observe] = new UnityAction (ShowTutoObserve);
		audio.Play ();
	}

	public void ShowTutoObserve() {
		audio.Play ();
		//On continue le tuto, télé plus observable mais livre observable
		availableInteractions.Remove (InteractionType.Observe);
		textMesh.text = ObserveMessage.Replace("\\n","\n");

		//On écoute l'événement pour changer le message (tâche complétée)
		EventManager.StartListening ("DoneObserving", new UnityAction (ShowTutoUse));

		//On arrête toutes les interactions pour permettre d'observer la télé elle-même
		GetComponent<BoxCollider> ().enabled = false;
	}

	public void ShowTutoUse () {
		audio.Play ();
		//On passe à l'utilisation avec la lampe : on arrête d'écouter l'observation
		EventManager.StopListening("DoneObserving");
		textMesh.text = UseMessage.Replace("\\n","\n");

		//On écoute l'événement pour changer le message (tâche complétée)
		EventManager.StartListening ("DoneUsing", new UnityAction (ShowToTake));
	}

	public void ShowToTake() {
		audio.Play ();
		//On passe au ramassage d'objet : on arrête d'écouter l'utilisation
		EventManager.StopListening("DoneUsing");
		textMesh.text = TakeMessage.Replace("\\n","\n");

		EventManager.StartListening ("DoneTaking", new UnityAction (ShowBegin));
	}

	public void ShowBegin() {
		audio.Play ();
		EventManager.StopListening ("DoneTaking");
		textMesh.text = BeginGameMessage.Replace("\\n","\n");
	}
}

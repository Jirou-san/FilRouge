using System;

public class Reponses
{
    #region Properties
    private int _ReponseId;
    private string _Content;
    private static int nombreReponse = 0;
    #endregion
    public Reponses(int ipReponseId, string ipContent)
	{
        this.ReponseId = ReponseId;
        this.Content = Content;
        nombreReponse++;
    }

   
    #region Accesseurs
    public int ReponseId { get => _ReponseId; set => _ReponseId = value; }
    public string Content { get => _Content; set => _Content = value; }
    #endregion
    #region Methods
    #endregion

}

using UnityEngine;

class ChatManager : MonoBehaviour
{
    public static ChatManager manager;
    public bool main = false;
    public bool ecc = false;
    public bool library = false;
    public bool gong = false;
    public bool starbucks1 = false;
    public bool starbucks2 = false;
    public bool stair1 = false;
    public bool stair2 = false;
    public bool media1 = false;
    public bool media2 = false;
    public bool gong1 = false;
    public bool gong2 = false;

    private void Awake() {
        if(manager == null)
        {
            manager = this;
            ecc = false;
            main = false;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(manager != this)
        {
            Destroy(this.gameObject);
        }
    }
}
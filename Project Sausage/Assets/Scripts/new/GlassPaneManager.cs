using UnityEngine;

public class GlassPaneManager : MonoBehaviour
{
    [System.Serializable]
    public class PaneRow
    {
        public GameObject paneLeft;
        public GameObject paneRight;
    }

    public PaneRow[] rows; // Assign rows manually in the Inspector

    private void Start()
    {
        InitializePanes();
    }

    private void InitializePanes()
    {
        foreach (PaneRow row in rows)
        {
            bool isLeftSolid = Random.value > 0.5f;

            if (row.paneLeft != null && row.paneRight != null)
            {
                PaneType leftPaneType = row.paneLeft.GetComponent<PaneType>();
                PaneType rightPaneType = row.paneRight.GetComponent<PaneType>();

                if (leftPaneType != null && rightPaneType != null)
                {
                    leftPaneType.isSolid = isLeftSolid;
                    rightPaneType.isSolid = !isLeftSolid;
                }
                else
                {
                    Debug.LogWarning("PaneType component missing on one of the panes in a row.");
                }
            }
            else
            {
                Debug.LogWarning("One of the panes in a row is not assigned.");
            }
        }
    }
}

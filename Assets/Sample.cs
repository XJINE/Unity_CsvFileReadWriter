using UnityEngine;

public class Sample : MonoBehaviour
{
    public int[] intArray;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CsvFileReadWriter.WriteToStreamingAssets("SampleDir", "SampleFile", intArray);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var (values, success) = CsvFileReadWriter.ReadFromStreamingAssets("SampleDir", "SampleFile");

            if (!success)
            {
                return;
            }

            intArray = new int[values.Length];

            for (var i = 0; i < intArray.Length; i++)
            {
                intArray[i] = int.Parse(values[i]);
            }
        }
    }

    private void OnGUI()
    {
        GUILayout.Label("R : Read Csv file from Streaming Assets");
        GUILayout.Label("W : Write Csv file into Streaming Assets");
    }
}
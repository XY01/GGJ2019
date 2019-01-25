using UnityEngine;
using System.Collections.Generic;

public class ShuffleBag
{
    #region Private state

    private List<int> m_indices;
    private int m_size;
    private int m_lastIndex;
    private bool m_PullShuffled;
    #endregion

    #region Public interface

    //Haxy hax but if u set pullshuffled to false the shufflebag will pull the indices in sequence
    //this is so we can easily swap between randomised zord events and sequential zord events if we need to
    public ShuffleBag(int size, bool pullShuffled = true)
    {
        m_lastIndex = -1;
        m_size = size;
        m_indices = new List<int>();
        m_PullShuffled = pullShuffled;
        Init();
    }

    public bool IsEmpty { get { return m_indices.Count == 0; } }

    public void Repopulate()
    {
        Init();
    }

    public int Pull(bool reinit = false)
    {
        if (m_PullShuffled)
        {
            // If bag is empty, repopulate it.
            if (m_indices.Count == 0)
            {
                if (reinit) Repopulate();
                else return -1;
            }

            int randomIndex, index;

            do
            {
                randomIndex = Random.Range(0, m_indices.Count);
                index = m_indices[randomIndex];
            }
            while (index == m_lastIndex);

            m_indices.RemoveAt(randomIndex);
            m_lastIndex = index;
            return index;
        }
        else
        {
            if (m_indices.Count == 0)
            {
                if (reinit) Repopulate();
                else return -1;
            }

            int index = m_indices[0];
            m_indices.RemoveAt(0);
            return index;
         }
    }

    #endregion

    #region Private implementation

    private void Init()
    {
        for (var i = 0; i < m_size; i++)
            m_indices.Add(i);
    }

    #endregion
}

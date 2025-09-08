private float[] SmoothVelocities(float[] rawVelocities)
{
    // Hinzufügen der neuen Geschwindgkeiten zum Buffer und Buffer anpassen
    velocityBuffer.Add((float[])rawVelocities.Clone());
    if (velocityBuffer.Count > smoothingWindowSize) {
        velocityBuffer.RemoveAt(0);
    }
    float[] result = new float[6];
    for (int i = 0; i < 6; i++) {
        // Glaetten mit dem EMP 
        smoothedVelocities[i] = (smoothingAlpha * rawVelocities[i]) + ((1f - smoothingAlpha) * smoothedVelocities[i]);
        // Anwenden des Moving Window Average
        if (velocityBuffer.Count >= smoothingWindowSize) {
            float windowSum = 0f;
            for (int j = 0; j < velocityBuffer.Count; j++)
            {
                windowSum += velocityBuffer[j][i];
            }
            result[i] = windowSum / velocityBuffer.Count;
        }
        else
        { result[i] = smoothedVelocities[i]; }
        // OutlierRejection
        float maxChange = maxJointVelocities[i] * velocityOutlierThreshold;
        if (velocityBuffer.Count > 1) {
              // GetMovingAverage berechnet den gleitenden Durschnitt zwischen der
              // letzten und vorletzen Bufferposition
            float previousSmoothed = velocityBuffer.Count >= 2 ? 
                GetMovingAverage(velocityBuffer, i, velocityBuffer.Count - 1) : smoothedVelocities[i];
            float change = Mathf.Abs(result[i] - previousSmoothed);
            // Überschreitet die Änderung der Geschwindigkeit den Schwellwert,
            // wird er auf den maximalen positiven oder negativen Wert begrenzt 
            if (change > maxChange) {
            result[i] = previousSmoothed + Mathf.Sign(result[i] - previousSmoothed) * maxChange; }
        }
    }
    return result;
}


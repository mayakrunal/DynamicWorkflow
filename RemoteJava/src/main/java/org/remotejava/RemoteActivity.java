package org.remotejava;

import io.temporal.activity.ActivityInterface;
import io.temporal.activity.ActivityMethod;

@ActivityInterface
public interface RemoteActivity {

    @ActivityMethod
    String Remote_Activity_2(String input);
}

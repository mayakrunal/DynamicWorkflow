package org.remotejava;


import io.temporal.activity.ActivityMethod;

public class RemoteActivityImpl implements RemoteActivity {

    @Override
    public String Remote_Activity_2(String input) {
        return "Java Remote Activity Says. " + input;
    }
}
